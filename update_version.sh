#!/bin/bash

# Read the version_info file and store its content in a variable
version=$(head -n 1 version_info)

# Ensure the version is not empty
if [[ -z "$version" ]]; then
  echo "Error: version_info file is empty."
  exit 1
fi

# Update the version string in the script
version_string="v$version"

# Perform git operations
git add .
git commit -m "update to $version_string"
git push
git tag -a "$version_string" -s -m "Version $version_string"
git push --tags

