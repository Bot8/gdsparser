#!/bin/bash
cd /app
# echo "Run dotnet restore"
# dotnet restore
# echo "Done dotnet restore"

echo "Run publish release"
dotnet publish -c Release -o /app/out
echo "Done publish release"

echo "Start application"
dotnet /app/out/GdsParser.dll

