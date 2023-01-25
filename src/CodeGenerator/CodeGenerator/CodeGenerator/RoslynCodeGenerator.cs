using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

using CodeGenerator.Properties;

namespace CodeGenerator.CodeGenerator
{
    public class CodeGenerator
    {
        static string _EntityNamespace, _MappingNamespace, _ServicesNamespace, _MockDataNamespace, _UnitTestNamespace, _QueryNamespace;

        public static string CreateReadServiceClass(string className)
        {
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("CodeGenerationSample")).NormalizeWhitespace();
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(_EntityNamespace)));
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Data")));
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Threading")));
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Threading.Tasks")));
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")));
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("FI.Services")));
            @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("FI.Queries")));

            var classDeclaration = SyntaxFactory.ClassDeclaration($"{className}LookupService");

            // Add the public modifier: (public class Order)
            classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            // Inherit DatabaseLookupService and implement I{className}LookupService:
            classDeclaration = classDeclaration.AddBaseListTypes(
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("DatabaseLookupService")),
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"I{className}LookupService")));

            classDeclaration = classDeclaration.AddBaseListTypes(
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("BaseEntity<Order>")),
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName("IHaveIdentity")));

            // Create a string variable: (bool canceled;)
            var variableDeclaration = SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName("bool"))
                .AddVariables(SyntaxFactory.VariableDeclarator("canceled"));

            //// Create a field declaration: (private bool canceled;)
            //var fieldDeclaration = SyntaxFactory.FieldDeclaration(variableDeclaration)
            //    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PrivateKeyword));

            //// Create a Property: (public int Quantity { get; set; })
            //var propertyDeclaration = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("int"), "Quantity")
            //    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            //    .AddAccessorListAccessors(
            //        SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
            //        SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)));

            //Create the constructor
            var constructor = SyntaxFactory.ConstructorDeclaration($"{className}LookupService");
            // Create a stament with the body of a method.

            var syntax = SyntaxFactory.ParseStatement("canceled = true;");

            // Create a method
            var methodDeclaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName($"List<className>"), "Lookup")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithBody(SyntaxFactory.Block(syntax));

            // Add the field, the property and method to the class.
            classDeclaration = classDeclaration.AddMembers(methodDeclaration);

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(classDeclaration);

            // Normalize and get code as string.
            return @namespace.NormalizeWhitespace().ToFullString();
        }

        public static void SetNameSpaces()
        {
            if (string.IsNullOrEmpty(Settings.Default.NamespaceSuffix))
            {
                _EntityNamespace = $"{Settings.Default.InfrastructureNamespace}.Entities";
                _MappingNamespace = $"{Settings.Default.Namespace}.Mappings";
                _ServicesNamespace = $"{Settings.Default.Namespace}.Services";
                _MockDataNamespace = $"{Settings.Default.Namespace}.Tests.MockData";
                _UnitTestNamespace = $"{Settings.Default.Namespace}.Tests.UnitTests";
                _QueryNamespace = $"{Settings.Default.Namespace}.Queries";
            }
            else
            {
                _EntityNamespace = $"{Settings.Default.InfrastructureNamespace}.Entities.{Settings.Default.NamespaceSuffix}";
                _MappingNamespace = $"{Settings.Default.Namespace}.Mappings.{Settings.Default.NamespaceSuffix}";
                _ServicesNamespace = $"{Settings.Default.Namespace}.Services.{Settings.Default.NamespaceSuffix}";
                _MockDataNamespace = $"{Settings.Default.Namespace}.Tests.{Settings.Default.NamespaceSuffix}.MockData";
                _UnitTestNamespace = $"{Settings.Default.Namespace}.Tests.{Settings.Default.NamespaceSuffix}.UnitTests";
                _QueryNamespace = $"{Settings.Default.Namespace}.Queries.{Settings.Default.NamespaceSuffix}";
            }
        }

    }
}
