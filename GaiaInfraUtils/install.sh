artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

mkdir -p $artifactsFolder

dotnet pack ./GaiaInfraUtils.csproj -c Release -o $artifactsFolder

rm -rf ~/.templateengine/packages/GaiaInfraUtils.*.nupkg
dotnet new install $artifactsFolder/GaiaInfraUtils.*.nupkg

#rm -rf ~/.nuget/packages/GaiaInfraUtils/1.0.0
# 在 Rider 的 NuGet 中，选择 Sources -> Feeds -> New feed + -> 加入本地包路径即可引用