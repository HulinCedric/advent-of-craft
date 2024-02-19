#!/bin/bash

# Translate the output of `dotnet libyear` to a markdown file
awk '
BEGIN {
    print "# Dependency Freshness Report\n";
    FS="│"; # Field separator for table parsing
}
/\.csproj/ { # Print project path as header
    # Remove ANSI colors and extract project path
    gsub(/\[[0-9;]*m/, ""); # Remove ANSI colors
    gsub(/\[2A/, ""); # Remove ANSI colors
    gsub(/\n/, ""); # Remove newline
    gsub(/\r/, ""); # Remove carriage return
    gsub(/^[\t ]+/, ""); # Trim leading spaces
    gsub(/[\t ]+$/, ""); # Trim trailing spaces
    
    print "## " $0 "\n"; 
    next;
}
/^│ Package / { # Match and format table header
    gsub(/│/, "|");
    print;
    print "|---------|-----------|----------|--------|----------|---------|";
    next;
}
/^│/ { # Match and format table body
    gsub(/│/, "|");
    print;
    next;
}
/Project is .* libyears behind/ { # Match and format summary lines
    gsub(/\[[0-9;]*m/, ""); # Remove ANSI colors
    gsub(/\[2A/, ""); # Remove ANSI colors
    gsub(/\n/, ""); # Remove newline
    gsub(/\r/, ""); # Remove carriage return
    gsub(/^[\t ]+/, ""); # Trim leading spaces
    gsub(/[\t ]+$/, ""); # Trim trailing spaces
    
    print "\n**" $0 "**\n"; # Highlight summary
}
/Total is/ { # Print total
    gsub(/\[[0-9;]*m/, ""); # Remove ANSI colors
    gsub(/\[2A/, ""); # Remove ANSI colors
    gsub(/\n/, ""); # Remove newline
    gsub(/\r/, ""); # Remove carriage return
    gsub(/^[\t ]+/, ""); # Trim leading spaces
    gsub(/[\t ]+$/, ""); # Trim trailing spaces
    
    print "## " $0 "";
}
' $1 > ${1%.txt}.md
