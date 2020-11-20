open FSharp.Json

type Table = Map<string,string>

let Inputfilename =
    @"J:\PTCR\Users\RECS\Macros\ReplacerFasteners\dataFastenersJson\table.json"

let json = System.IO.File.ReadAllText(Inputfilename)

type ConversionChartList = Map<string, Table>

let deserializedTableData = Json.deserialize<ConversionChartList> json

let matching setOfData =
    match setOfData with
        | Some table -> table
        | None -> None

let getTable (collectionsChart: ConversionChartList) (jdeNum:string)=
    collectionsChart.TryGetValue jdeNum

let tableConversion = getTable deserializedTableData "105990"

let tableStatus = (fst tableConversion)

let material = "imperial zinc"

let partnumber =
    if tableStatus then
        let chart =  snd tableConversion
        let equivalent:string = chart.[material]
        equivalent
    else ""

printfn "%s" partnumber