set shell := ["sh", "-c"]
set windows-shell := ["pwsh.exe", "-c"]

alias b := build

# Build the project
build *FLAGS:
    dotnet build {{FLAGS}}

# Package up the plugin to be uploaded
package: (build "-p:BuildStaging=true")
    tcli build --config-path .\artifacts\thunderstore.toml

# Upload the Plugin to ThunderStore
publish:
    tcli publish --config-path .\artifacts\thunderstore.toml

# Generate the changelog for a new version
gen-changelog tag:
    git cliff --tag {{tag}} --exclude-path "./CHANGELOG.md" --prepand "./CHANGELOG.md" -o CHANGELOG.md