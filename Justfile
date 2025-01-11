set shell := ["sh", "-c"]
set windows-shell := ["pwsh.exe", "-c"]

alias b := build

export STRAFTAT_REFERENCES := "C:\\Program Files (x86)\\Steam\\steamapps\\common\\STRAFTAT\\STRAFTAT_Data\\Managed"

gen-changelog:
    git cliff --exclude-path "CHANGELOG.md" -o .\CHANGELOG.md

# Build the project
build *FLAGS:
    dotnet build {{FLAGS}}

package: (build "-c Release")
    tcli build --config-path .\artifacts\tspublish\thunderstore.toml
