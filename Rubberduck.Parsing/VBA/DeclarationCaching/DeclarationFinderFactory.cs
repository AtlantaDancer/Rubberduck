﻿using System.Collections.Generic;
using Rubberduck.Parsing.Annotations;
using Rubberduck.Parsing.Symbols;
using Rubberduck.VBEditor;
using Rubberduck.VBEditor.SafeComWrappers.Abstract;

namespace Rubberduck.Parsing.VBA.DeclarationCaching
{
    public class DeclarationFinderFactory : IDeclarationFinderFactory 
    {
        public DeclarationFinder Create(IReadOnlyList<Declaration> declarations, 
            IEnumerable<IParseTreeAnnotation> annotations, 
            IReadOnlyList<UnboundMemberDeclaration> unresolvedMemberDeclarations, 
            IReadOnlyDictionary<QualifiedModuleName, IReadOnlyCollection<IdentifierReference>> unboundDefaultMemberAccesses,
            IReadOnlyDictionary<QualifiedModuleName, IReadOnlyCollection<IdentifierReference>> failedLetCoercions,
            IReadOnlyDictionary<QualifiedModuleName, IReadOnlyCollection<IdentifierReference>> failedProcedureCoercions,
            IHostApplication hostApp)
        {
            return new DeclarationFinder(declarations, annotations, unresolvedMemberDeclarations, unboundDefaultMemberAccesses, failedLetCoercions, failedProcedureCoercions, hostApp);
        }

        public void Release(DeclarationFinder declarationFinder)
        {
        }
    }
}
