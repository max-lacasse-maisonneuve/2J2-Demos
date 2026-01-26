#!/bin/bash

# Script to filter files and folders using git ls-files and create a zip with only the included files

ROOT_DIR="${PWD}";


# Check if argument is provided
if [ $# -eq 0 ]; then
    echo "Usage: $0 <target_directory> [output_zip_name]"
    echo "Example: $0 /path/to/dir output.zip"
    exit 1
fi

TARGET_DIR="$1"
DEFAULT_FOLDER_ZIP=${TARGET_DIR%/}
OUTPUT_ZIP="${2:-${DEFAULT_FOLDER_ZIP}.zip}"

# Check if target directory exists
if [ ! -d "$TARGET_DIR" ]; then
    echo "Error: Directory '$TARGET_DIR' does not exist"
    exit 1
fi

# Create a temporary file to store filtered files
TEMP_FILE=$(mktemp)

# Get all untracked files using git ls-files
# We need to run this command from the git repository root
#cd "$TARGET_DIR"
#GIT_ROOT=$(git rev-parse --show-toplevel)
cd "$TARGET_DIR"

# Get all untracked files and filter out directories
git ls-files --others --exclude-standard -c | while read -r file; do
    if [ -f "$file" ]; then
        echo "$file"
    fi
done > "$TEMP_FILE"

# Check if we have any files to zip
if [ ! -s "$TEMP_FILE" ]; then
    echo "No files found to include in zip"
    rm "$TEMP_FILE"
    exit 1
fi

# Create the zip file with only files (not directories)
echo "Creating zip file: $OUTPUT_ZIP"
zip -r "$OUTPUT_ZIP" -@ < "$TEMP_FILE"

mv "$OUTPUT_ZIP" "$ROOT_DIR"

# Cleanup
rm "$TEMP_FILE"

echo "Zip file created successfully: $OUTPUT_ZIP"