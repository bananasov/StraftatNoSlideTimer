set shell := ["sh", "-c"]
set windows-shell := ["pwsh.exe", "-c"]

alias b := build

export STRAFTAT_REFERENCES := "C:\\Program Files (x86)\\Steam\\steamapps\\common\\STRAFTAT\\STRAFTAT_Data\\Managed"

# Build the project
build *FLAGS:
    dotnet build {{FLAGS}}


gen-changelog:
    git cliff --exclude-path "CHANGELOG.md" -o .\CHANGELOG.md
