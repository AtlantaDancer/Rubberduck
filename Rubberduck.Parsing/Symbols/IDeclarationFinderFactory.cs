﻿using Rubberduck.Parsing.Annotations;
using System.Collections.Generic;
using Rubberduck.Parsing.VBA.DeclarationCaching;
using Rubberduck.VBEditor;
using Rubberduck.VBEditor.SafeComWrappers.Abstract;

namespace Rubberduck.Parsing.Symbols
{
    public interface IDeclarationFinderFactory
    {
        DeclarationFinder Create(
            IReadOnlyList<Declaration> declarations, 
            IEnumerable<IParseTreeAnnotation> annotations, 
            IReadOnlyList<UnboundMemberDeclaration> unresolvedMemberDeclarations, 
            IReadOnlyDictionary<QualifiedModuleName, IReadOnlyCollection<IdentifierReference>> unboundDefaultMemberAccesses,
            IReadOnlyDictionary<QualifiedModuleName, IReadOnlyCollection<IdentifierReference>> failedLetCoercions,
            IReadOnlyDictionary<QualifiedModuleName, IReadOnlyCollection<IdentifierReference>> failedProcedureCoercions,
            IHostApplication hostApp);
        void Release(DeclarationFinder declarationFinder);
    }
}
