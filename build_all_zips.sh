#!/bin/bash

# Find all folders in the current working directory
for folder in */; do
  # Remove the trailing slash from the folder name
  folder_name=${folder%/}
  # Run the create_zip_from_folder command for each folder
  ./create_zip_from_folder.sh "$folder_name" "$folder_name.zip"
done