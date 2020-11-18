open FSharp.Json

let Inputfilename = @"C:\Users\recs\Documents\PT_Documents\scripts\extract_data_json\nfj\table.json"
let json = System.IO.File.ReadAllText(Inputfilename)

type Table = {
   ``imperial zinc``: string
   ``metric zinc``: string
   ``imperial ss-304``: string
   ``metric ss-304``: string
   ``imperial ss-316``: string
   ``metric ss-316``: string
}

type ConversionChart = Map<string, Table>

type ItemCollection = ConversionChart list

let deserialized = Json.deserialize<ItemCollection> json

let matching x =
    match x with
        | Some table -> table
        | None -> None

let getTable (collectionsPart: ItemCollection) (jdeNum:string)=
    collectionsPart
    |> List.tryFind (fun t -> t.ContainsKey(jdeNum))

let setKeyValue = getTable deserialized "105990"
let chart = setKeyValue.Value.Item("105990")
let equivalent = chart.``metric ss-304``

printfn "%s" equivalent

// implement if key not found.

