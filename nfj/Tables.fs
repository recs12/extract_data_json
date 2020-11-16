open FSharp.Json

type Table = Map<string, string>

type ConversionChart = Map<string, Table>

type ItemCollection = ConversionChart list

let Inputfilename = @"C:\Users\Slimane\Desktop\dev\json\nfj\table.json"
let json = System.IO.File.ReadAllText(Inputfilename)
let deserialized = Json.deserialize<ItemCollection> json

type EquivalentJde =  Option<string>

let checkIt x =
    match x with
        | Some item -> printfn "%s" item
        | None -> printfn "the value is None"

let searchDetails (collectionsPart: ItemCollection) (jdeNum: string) =
    collectionsPart
        |> List.tryFind (fun (k,v) -> v when k = jdeNum)
        |> checkIt

// let item = searchDetails deserialized "55110020"

// printfn "%s" item
// printfn "%A" deserialized

