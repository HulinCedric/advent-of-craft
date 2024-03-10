using System.Collections.Immutable;

namespace Day21.FunctionalCore_ImperativeShell.Domain;

public record FileContent(string FileName, ImmutableList<string> Lines);