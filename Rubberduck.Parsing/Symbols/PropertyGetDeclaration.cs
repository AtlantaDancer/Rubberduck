﻿using Antlr4.Runtime;
using Rubberduck.Parsing.Annotations;
using Rubberduck.Parsing.ComReflection;
using Rubberduck.Parsing.Grammar;
using Rubberduck.Parsing.VBA;
using Rubberduck.VBEditor;
using System.Collections.Generic;
using System.Linq;

namespace Rubberduck.Parsing.Symbols
{
    public sealed class PropertyGetDeclaration : PropertyDeclaration
    {
        public PropertyGetDeclaration(
            QualifiedMemberName name,
            Declaration parent,
            Declaration parentScope,
            string asTypeName,
            VBAParser.AsTypeClauseContext asTypeContext,
            string typeHint,
            Accessibility accessibility,
            ParserRuleContext context,
            Selection selection,
            bool isArray,
            bool isUserDefined,
            IEnumerable<IAnnotation> annotations,
            Attributes attributes)
            : base(
                  name,
                  parent,
                  parentScope,
                  asTypeName,
                  asTypeContext,
                  typeHint,
                  accessibility,
                  DeclarationType.PropertyGet,
                  context,
                  selection,
                  isArray,
                  isUserDefined,
                  annotations,
                  attributes)
        { }

        public PropertyGetDeclaration(ComMember member, Declaration parent, QualifiedModuleName module, Attributes attributes)
            : this(
                module.QualifyMemberName(member.Name),
                parent,
                parent,
                member.AsTypeName.TypeName,
                null,
                null,
                Accessibility.Global,
                null,
                Selection.Home,
                member.AsTypeName.IsArray,
                false,
                null,
                attributes)
        {
            AddParameters(member.Parameters.Select(decl => new ParameterDeclaration(decl, this, module)));
        }

        public PropertyGetDeclaration(ComField field, Declaration parent, QualifiedModuleName module, Attributes attributes)
            : this(
                module.QualifyMemberName(field.Name),
                parent,
                parent,
                field.ValueType,
                null,
                null,
                Accessibility.Global,
                null,
                Selection.Home,
                false,  //TODO - check this assumption.
                false,
                null,
                attributes)
        { }

        protected override bool Implements(ICanBeInterfaceMember member)
        {
            return (member.DeclarationType == DeclarationType.PropertyGet || member.DeclarationType == DeclarationType.Variable)
                   && member.IsInterfaceMember
                   && IsInterfaceImplementation
                   && IdentifierName.Equals($"{member.InterfaceDeclaration.IdentifierName}_{member.IdentifierName}");
        }
    }
}
