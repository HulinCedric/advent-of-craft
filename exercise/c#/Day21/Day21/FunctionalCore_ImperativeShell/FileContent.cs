using System.Collections.Immutable;

namespace Day21.FunctionalCore_ImperativeShell;

public record FileContent(string FileName, ImmutableList<string> Lines);