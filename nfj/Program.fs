﻿open FSharp.Json

type Table = {
   ``imperial zinc``: string
   ``metric zinc``: string
   ``imperial ss-304``: string
   ``metric ss-304``: string
   ``imperial ss-316``: string
   ``metric ss-316``: string
}

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

let tableConversion = getTable deserializedTableData "0105990"

let tableStatus = (fst tableConversion)

let partnumber =
    if tableStatus then
        let chart =  snd tableConversion
        let equivalent:string = chart.``metric ss-304``
        equivalent
    else ""

printfn "%s" partnumber