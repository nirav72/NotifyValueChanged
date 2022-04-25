﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TomLonghurst.Events.NotifyContextChanged.SourceGeneration.Implementation;

internal class FieldSyntaxReciever : ISyntaxContextReceiver
{
    public List<IFieldSymbol> IdentifiedFields { get; } = new();

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        if (context.Node is FieldDeclarationSyntax fieldDeclaration && fieldDeclaration.AttributeLists.Any())
        {
            var variableDeclaration = fieldDeclaration.Declaration.Variables;
            foreach(var variable in variableDeclaration)
            {
                var field = context.SemanticModel.GetDeclaredSymbol(variable);
                if (field is IFieldSymbol fieldInfo && fieldInfo.GetAttributes().Any(x=> x.AttributeClass.ToDisplayString() == typeof(NotifyContextChangeAttribute).FullName))
                {
                    IdentifiedFields.Add(fieldInfo);
                }
            }
        }
    }
}