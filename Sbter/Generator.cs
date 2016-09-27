using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public class Generator
    {

        StringBuilder sb = new StringBuilder();

        public Generator(string code,string osbpath, string jsonpath)
        {
            string code_aux2 = ((code.Replace("_action_", " public static ")).TrimEnd());
            string code_aux = code_aux2.Remove(code_aux2.Length-1).Replace("Rand(", " Maths.Rand( ");
            string finalcode ="using System; using System.IO; using System.Text; using System.Collections.Generic; using Sbter; using Sbter.Utilities;" + " namespace SB{public class Program{ " +
                   code_aux + " Osw.Write(\""+jsonpath+ "\");\r\nvar t = File.ReadAllText(\"" + jsonpath + "\");\r\n" +
                   "SBParser sw = new SBParser(t);\r\n sw.WriteToOsb(\"" + osbpath + "\");}\r\n}\r\n}";

            File.WriteAllText("final_cs.cs",finalcode);
            
            Generate(finalcode);



        }

        private void Generate(string code)
        {

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            // Reference to System.Drawing library
            parameters.ReferencedAssemblies.Add("Sbter.dll");
            // True - memory generation, false - external file generation
            parameters.GenerateInMemory = true;
            // True - exe file generation, false - dll file generation
            parameters.GenerateExecutable = true;

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

            if (results.Errors.HasErrors)
            {

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error line ({0}): {1}", error.Line, error.ErrorText));

                }

                //throw new InvalidOperationException(sb.ToString());
            }
            if (sb.ToString() != "")
            {
                File.WriteAllText("error.log", sb.ToString());
            }
            try {
                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("SB.Program");
                MethodInfo main = program.GetMethod("Main");
                main.Invoke(null, null);
            }catch(Exception e)
            {
                File.WriteAllText("Invoke.txt",e.ToString());
            }

        }

        public string GetError()
        {
            return sb.ToString();
        }

    }
}
