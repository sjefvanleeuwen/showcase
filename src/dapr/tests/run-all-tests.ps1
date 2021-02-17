foreach ($i in "dapr.gql.basket","dapr.gql.inventory","dapr.gql.customer","dapr.gql.payment","dapr.gql.product")
{
    dotnet test ./$i.tests/ --collect:"XPlat Code Coverage"
    dotnet $env:UserProfile\.nuget\packages\reportgenerator\4.8.5\tools\net5.0\ReportGenerator.dll `
    "-reports:$i.tests/TestResults/*/coverage.cobertura.xml" `
    "-targetdir:../../../docs/tests/unit-tests/$i.tests" -reporttypes:"HtmlChart;Badges;Html"

    #Remove-Item ./$i.tests/TestResults/* -Recurse -Force
}
