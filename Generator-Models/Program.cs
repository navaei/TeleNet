using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TeleNet.CodeGenerator
{
    class Program_
    {
        static List<string> keywords = new List<string>(new string[] { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "async", "await", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "partial", "remove", "select", "set", "value", "var", "where", "where", "yield" });
        static List<string> interfacesList = new List<string>();
        static List<string> classesList = new List<string>();
        static List<Constructor> OldTypes = new List<Constructor>();
        static List<Method> OldMethods = new List<Method>();
        private const int DefaultLayer = 140;


        static void Main(string[] args)
        {
            Console.WriteLine("Starting....");
            //if (args.Count() == 0) url = "tl-schema.json"; else url = args[0];
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "tl-schema-*");
            files = files.OrderBy(f =>
                    int.Parse(f.Substring(f.LastIndexOf("-", StringComparison.Ordinal) + 1,
                        f.LastIndexOf(".", StringComparison.Ordinal) - f.LastIndexOf("-", StringComparison.Ordinal) -
                        1)))
                .ToArray();

            foreach (var file in files)
            {
                try
                {
                    GenerateFromJson(file);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            Console.WriteLine("All layers model created successfully");
            Console.ReadKey();
        }

        private static void GenerateFromJson(string templatePath)
        {
            var absStyle = File.ReadAllText("ConstructorAbs.tmp");
            var normalStyle = File.ReadAllText("Constructor.tmp");
            var methodStyle = File.ReadAllText("Method.tmp");
            //string method = File.ReadAllText("constructor.tt");
            var Json = "";
            var len = templatePath.LastIndexOf(".") - templatePath.LastIndexOf("-") - 1;
            var layer = templatePath.Substring(templatePath.LastIndexOf("-") + 1, len);
            if (int.Parse(layer) == DefaultLayer)
                layer = "";

            Json = File.ReadAllText(templatePath);
            FileStream file = File.OpenWrite("Result.cs");
            StreamWriter sw = new StreamWriter(file);
            Schema schema = JsonConvert.DeserializeObject<Schema>(Json);

            if (OldTypes.Any())
                schema.constructors = schema.constructors.Where(m => !OldTypes.Any(om => om.id == m.id)).ToList();
            OldTypes.AddRange(schema.constructors);

            foreach (var c in schema.constructors)
            {
                if (c.id == 0)
                    continue;

                interfacesList.Add(c.type);
                classesList.Add(c.predicate);
            }

            foreach (var c in schema.constructors)
            {
                if (c.id == 0)
                    continue;

                var types = schema.constructors.Where(x => x.type == c.type);
                if (types.Count() > 1)
                {
                    string path = (GetNameSpace(c.type).Replace("TeleNet.Models.TL", "TL" + layer + "\\").Replace(".", "") + "\\" + GetNameofClass(c.type, true) + ".cs").Replace("\\\\", "\\");
                    FileStream classFile = MakeFile(path);
                    using (StreamWriter writer = new StreamWriter(classFile))
                    {
                        string nspace = (GetNameSpace(c.type).Replace("TeleNet.Models.TL", "TL" + layer + "\\").Replace(".", "")).Replace("\\\\", "\\").Replace("\\", ".");
                        if (nspace.EndsWith("."))
                            nspace = nspace.Remove(nspace.Length - 1, 1);
                        string temp = absStyle.Replace("/* NAMESPACE */", "TeleNet.Models." + nspace);
                        temp = temp.Replace("/* NAME */", GetNameofClass(c.type, true));
                        writer.Write(temp);
                        writer.Close();
                        classFile.Close();
                    }
                }
                else
                {
                    interfacesList.Remove(types.First().type);
                    types.First().type = "himself";
                }
            }

            foreach (var c in schema.constructors)
            {
                if (c.id == 0)
                    continue;

                string path = (GetNameSpace(c.predicate).Replace("TeleNet.Models.TL", "TL" + layer + "\\").Replace(".", "") + "\\" + GetNameofClass(c.predicate, false) + ".cs").Replace("\\\\", "\\");
                FileStream classFile = MakeFile(path);
                using (StreamWriter writer = new StreamWriter(classFile))
                {
                    #region About Class
                    string nspace = (GetNameSpace(c.predicate).Replace("TeleNet.Models.TL", "TL" + layer + "\\").Replace(".", "")).Replace("\\\\", "\\").Replace("\\", ".");
                    if (nspace.EndsWith("."))
                        nspace = nspace.Remove(nspace.Length - 1, 1);
                    string temp = normalStyle.Replace("/* NAMESPACE */", "TeleNet.Models." + nspace);
                    temp = (c.type == "himself") ? temp.Replace("/* PARENT */", "TLObject") : temp.Replace("/* PARENT */", GetNameofClass(c.type, true));
                    temp = temp.Replace("/*Constructor*/", c.id.ToString());
                    temp = temp.Replace("/* NAME */", GetNameofClass(c.predicate, false));
                    #endregion
                    #region Fields
                    string fields = "";
                    foreach (var tmp in c.Params)
                    {
                        fields += $"     public {CheckForFlagBase(tmp.type, GetTypeName(tmp.type))} {CheckForKeywordAndPascalCase(tmp.name)} " + "{get;set;}" + Environment.NewLine;
                    }
                    temp = temp.Replace("/* PARAMS */", fields);
                    #endregion
                    #region ComputeFlagFunc
                    if (!c.Params.Any(x => x.name.Equals("Flags", StringComparison.CurrentCultureIgnoreCase))) temp = temp.Replace("/* COMPUTE */", "");
                    else
                    {
                        var compute = "Flags = 0;" + Environment.NewLine;
                        foreach (var param in c.Params.Where(x => IsFlagBase(x.type)))
                        {
                            if (IsTrueFlag(param.type))
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.name)} ? (Flags | {GetBitMask(param.type)}) : (Flags & ~{GetBitMask(param.type)});" + Environment.NewLine;
                            }
                            else
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.name)} != null ? (Flags | {GetBitMask(param.type)}) : (Flags & ~{GetBitMask(param.type)});" + Environment.NewLine;
                            }
                        }
                        temp = temp.Replace("/* COMPUTE */", compute);
                    }
                    #endregion
                    #region SerializeFunc
                    var serialize = "";

                    if (c.Params.Any(x => x.name.Equals("Flags", StringComparison.CurrentCultureIgnoreCase))) serialize += "ComputeFlags();" + Environment.NewLine + "bw.Write(Flags);" + Environment.NewLine;
                    foreach (var p in c.Params.Where(x => x.name != "Flags" && x.name != "flags"))
                    {
                        serialize += WriteWriteCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* SERIALIZE */", serialize);
                    #endregion
                    #region DeSerializeFunc
                    var deserialize = "";

                    foreach (var p in c.Params)
                    {
                        deserialize += WriteReadCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* DESERIALIZE */", deserialize);
                    #endregion
                    writer.Write(temp);
                    writer.Close();
                    classFile.Close();
                }
            }

            if (OldMethods.Any())
                schema.methods = schema.methods.Where(m => !OldMethods.Any(om => om.id == m.id)).ToList();
            OldMethods.AddRange(schema.methods);

            foreach (var c in schema.methods)
            {
                if (c.id == 0)
                    continue;

                string path = (GetNameSpace(c.method).Replace("TeleNet.Models.TL", "TL" + layer + "\\").Replace(".", "") + "\\" + GetNameofClass(c.method, false, true) + ".cs").Replace("\\\\", "\\");
                FileStream classFile = MakeFile(path);
                using (StreamWriter writer = new StreamWriter(classFile))
                {
                    #region About Class
                    string nspace = (GetNameSpace(c.method).Replace("TeleNet.Models.TL", "TL" + layer + "\\").Replace(".", "")).Replace("\\\\", "\\").Replace("\\", ".");
                    if (nspace.EndsWith("."))
                        nspace = nspace.Remove(nspace.Length - 1, 1);
                    string temp = methodStyle.Replace("/* NAMESPACE */", "TeleNet.Models." + nspace);
                    temp = temp.Replace("/* PARENT */", "TLMethod");
                    temp = temp.Replace("/*Constructor*/", c.id.ToString());
                    temp = temp.Replace("/* NAME */", GetNameofClass(c.method, false, true));
                    #endregion
                    #region Fields
                    string fields = "";
                    foreach (var tmp in c.Params)
                    {
                        fields += $"        public {CheckForFlagBase(tmp.type, GetTypeName(tmp.type))} {CheckForKeywordAndPascalCase(tmp.name)} " + "{get;set;}" + Environment.NewLine;
                    }
                    fields += $"public {CheckForFlagBase(c.type, GetTypeName(c.type))} Response " + "{ get; set;}" + Environment.NewLine;
                    temp = temp.Replace("/* PARAMS */", fields);
                    #endregion
                    #region ComputeFlagFunc
                    if (!c.Params.Any(x => x.name.Equals("Flags", StringComparison.CurrentCultureIgnoreCase))) temp = temp.Replace("/* COMPUTE */", "");
                    else
                    {
                        var compute = "Flags = 0;" + Environment.NewLine;
                        foreach (var param in c.Params.Where(x => IsFlagBase(x.type)))
                        {
                            if (IsTrueFlag(param.type))
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.name)} ? (Flags | {GetBitMask(param.type)}) : (Flags & ~{GetBitMask(param.type)});" + Environment.NewLine;
                            }
                            else
                            {
                                compute += $"Flags = {CheckForKeywordAndPascalCase(param.name)} != null ? (Flags | {GetBitMask(param.type)}) : (Flags & ~{GetBitMask(param.type)});" + Environment.NewLine;
                            }
                        }
                        temp = temp.Replace("/* COMPUTE */", compute);
                    }
                    #endregion
                    #region SerializeFunc
                    var serialize = "";

                    if (c.Params.Any(x => x.name.Equals("Flags", StringComparison.CurrentCultureIgnoreCase))) serialize += "ComputeFlags();" + Environment.NewLine + "bw.Write(Flags);" + Environment.NewLine;
                    foreach (var p in c.Params.Where(x => x.name != "Flags" && x.name != "flags"))
                    {
                        serialize += WriteWriteCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* SERIALIZE */", serialize);
                    #endregion
                    #region DeSerializeFunc
                    var deserialize = "";

                    foreach (var p in c.Params)
                    {
                        deserialize += WriteReadCode(p) + Environment.NewLine;
                    }
                    temp = temp.Replace("/* DESERIALIZE */", deserialize);
                    #endregion
                    #region DeSerializeRespFunc
                    var deserializeResp = "";
                    Param p2 = new Param() { name = "Response", type = c.type };
                    deserializeResp += WriteReadCode(p2) + Environment.NewLine;
                    temp = temp.Replace("/* DESERIALIZEResp */", deserializeResp);
                    #endregion
                    writer.Write(temp);
                    writer.Close();
                    classFile.Close();
                }
            }

            file.Close();
            Console.WriteLine("End layer:" + layer);
        }

        public static string FormatName(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            if (input.IndexOf('.') != -1)
            {
                input = input.Replace(".", " ");
                var temp = "";
                foreach (var s in input.Split(' '))
                {
                    temp += FormatName(s) + " ";
                }
                input = temp.Trim();
            }
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        public static string CheckForKeywordAndPascalCase(string name)
        {
            name = name.Replace("_", " ");
            name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
            name = name.Replace(" ", "");

            if (keywords.Contains(name)) return "@" + name;
            return name;
        }
        public static string GetNameofClass(string type, bool isinterface = false, bool ismethod = false)
        {
            if (!ismethod)
            {
                if (type.IndexOf('.') != -1 && type.IndexOf('?') == -1)
                    return isinterface ? "TLAbs" + FormatName(type.Split('.')[1]) : "TL" + FormatName(type.Split('.')[1]);
                else if (type.IndexOf('.') != -1 && type.IndexOf('?') != -1)
                    return isinterface ? "TLAbs" + FormatName(type.Split('?')[1]) : "TL" + FormatName(type.Split('?')[1]);
                else
                    return isinterface ? "TLAbs" + FormatName(type) : "TL" + FormatName(type);
            }
            else
            {
                if (type.IndexOf('.') != -1 && type.IndexOf('?') == -1)
                    return "TLRequest" + FormatName(type.Split('.')[1]);
                else if (type.IndexOf('.') != -1 && type.IndexOf('?') != -1)
                    return "TLRequest" + FormatName(type.Split('?')[1]);
                else
                    return "TLRequest" + FormatName(type);
            }
        }
        private static bool IsFlagBase(string type)
        {
            return type.IndexOf("?") != -1;
        }
        private static int GetBitMask(string type)
        {
            return (int)Math.Pow((double)2, (double)int.Parse(type.Split('?')[0].Split('.')[1]));
        }
        private static bool IsTrueFlag(string type)
        {
            return type.Split('?')[1] == "true";
        }
        public static string GetNameSpace(string type)
        {
            if (type.IndexOf('.') != -1)
                return "TeleNet.Models.TL" + FormatName(type.Split('.')[0]);
            else
                return "TeleNet.Models.TL";
        }
        public static string CheckForFlagBase(string type, string result)
        {
            if (type.IndexOf('?') == -1)
                return result;
            else
            {
                string innerType = type.Split('?')[1];
                if (innerType == "true") return result;
                else if ((new string[] { "bool", "int", "uint", "long", "double" }).Contains(result)) return result + "?";
                else return result;
            }
        }
        public static string GetTypeName(string type)
        {
            switch (type.ToLower())
            {
                case "#":
                case "int":
                    return "int";
                case "uint":
                    return "uint";
                case "long":
                    return "long";
                case "double":
                    return "double";
                case "string":
                    return "string";
                case "bytes":
                    return "byte[]";
                case "true":
                case "bool":
                    return "bool";
                case "!x":
                    return "TLObject";
                case "x":
                    return "TLObject";
            }

            if (type.StartsWith("Vector"))
                return "TLVector<" + GetTypeName(type.Replace("Vector<", "").Replace(">", "")) + ">";

            if (type.ToLower().Contains("inputcontact"))
                return "TLInputPhoneContact";


            if (type.IndexOf('.') != -1 && type.IndexOf('?') == -1)
            {

                if (interfacesList.Any(x => x.ToLower() == (type).ToLower()))
                    return FormatName(type.Split('.')[0]) + "." + "TLAbs" + type.Split('.')[1];
                else if (classesList.Any(x => x.ToLower() == (type).ToLower()))
                    return FormatName(type.Split('.')[0]) + "." + "TL" + type.Split('.')[1];
                else
                    return FormatName(type.Split('.')[1]);
            }
            else if (type.IndexOf('?') == -1)
            {
                if (interfacesList.Any(x => x.ToLower() == type.ToLower()))
                    return "TLAbs" + type;
                else if (classesList.Any(x => x.ToLower() == type.ToLower()))
                    return "TL" + type;
                else
                    return type;
            }
            else
            {
                return GetTypeName(type.Split('?')[1]);
            }


        }
        public static string LookTypeInLists(string src)
        {
            if (interfacesList.Any(x => x.ToLower() == src.ToLower()))
                return "TLAbs" + FormatName(src);
            else if (classesList.Any(x => x.ToLower() == src.ToLower()))
                return "TL" + FormatName(src);
            else
                return src;
        }
        public static string WriteWriteCode(Param p, bool flag = false)
        {
            switch (p.type.ToLower())
            {
                case "#":
                case "int":
                    return flag ? $"bw.Write({CheckForKeywordAndPascalCase(p.name)}.Value);" : $"bw.Write({CheckForKeywordAndPascalCase(p.name)});";
                case "long":
                    return flag ? $"bw.Write({CheckForKeywordAndPascalCase(p.name)}.Value);" : $"bw.Write({CheckForKeywordAndPascalCase(p.name)});";
                case "string":
                    return $"StringUtil.Serialize({CheckForKeywordAndPascalCase(p.name)},bw);";
                case "bool":
                    return flag ? $"BoolUtil.Serialize({CheckForKeywordAndPascalCase(p.name)}.Value,bw);" : $"BoolUtil.Serialize({CheckForKeywordAndPascalCase(p.name)},bw);";
                case "true":
                    return $"BoolUtil.Serialize({CheckForKeywordAndPascalCase(p.name)},bw);";
                case "bytes":
                    return $"BytesUtil.Serialize({CheckForKeywordAndPascalCase(p.name)},bw);";
                case "double":
                    return flag ? $"bw.Write({CheckForKeywordAndPascalCase(p.name)}.Value);" : $"bw.Write({CheckForKeywordAndPascalCase(p.name)});";
                default:
                    if (!IsFlagBase(p.type))
                        return $"ObjectUtils.SerializeObject({CheckForKeywordAndPascalCase(p.name)},bw);";
                    else
                    {
                        if (IsTrueFlag(p.type))
                            return $"";
                        else
                        {
                            Param p2 = new Param() { name = p.name, type = p.type.Split('?')[1] };
                            return $"if ((Flags & {GetBitMask(p.type).ToString()}) != 0)" + Environment.NewLine +
                                WriteWriteCode(p2, true);
                        }
                    }
            }
        }
        public static string WriteReadCode(Param p)
        {
            switch (p.type.ToLower())
            {
                case "#":
                case "int":
                    return $"{CheckForKeywordAndPascalCase(p.name)} = br.ReadInt32();";
                case "long":
                    return $"{CheckForKeywordAndPascalCase(p.name)} = br.ReadInt64();";
                case "string":
                    return $"{CheckForKeywordAndPascalCase(p.name)} = StringUtil.Deserialize(br);";
                case "bool":
                case "true":
                    return $"{CheckForKeywordAndPascalCase(p.name)} = BoolUtil.Deserialize(br);";
                case "bytes":
                    return $"{CheckForKeywordAndPascalCase(p.name)} = BytesUtil.Deserialize(br);";
                case "double":
                    return $"{CheckForKeywordAndPascalCase(p.name)} = br.ReadDouble();";
                default:
                    if (!IsFlagBase(p.type))
                    {
                        if (p.type.ToLower().Contains("vector"))
                        {
                            return $"{CheckForKeywordAndPascalCase(p.name)} = ({GetTypeName(p.type)})ObjectUtils.DeserializeVector<{GetTypeName(p.type).Replace("TLVector<", "").Replace(">", "")}>(br);";
                        }
                        else return $"{CheckForKeywordAndPascalCase(p.name)} = ({GetTypeName(p.type)})ObjectUtils.DeserializeObject(br);";
                    }
                    else
                    {
                        if (IsTrueFlag(p.type))
                            return $"{CheckForKeywordAndPascalCase(p.name)} = (Flags & {GetBitMask(p.type).ToString()}) != 0;";
                        else
                        {
                            Param p2 = new Param() { name = p.name, type = p.type.Split('?')[1] };
                            return $"if ((Flags & {GetBitMask(p.type).ToString()}) != 0)" + Environment.NewLine +
                                WriteReadCode(p2) + Environment.NewLine +
                            "else" + Environment.NewLine +
                                $"{CheckForKeywordAndPascalCase(p.name)} = null;" + Environment.NewLine;
                        }
                    }
            }
        }

        public static FileStream MakeFile(string path)
        {
            path = path.Replace("<", "-").Replace(">", "_");
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            if (File.Exists(path))
                File.Delete(path);
            return File.OpenWrite(path);
        }
    }

}