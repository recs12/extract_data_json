open FSharp.Json

type FastenerDetails = {
       JdeNumber: string
       Revision: string
       Filename: string
}

type ItemCollection = FastenerDetails list

let Inputfilename : string = @"C:\Users\Slimane\Desktop\dev\json\nfj\fasteners.json"

let json :string = System.IO.File.ReadAllText(Inputfilename)

let deserialized: ItemCollection = Json.deserialize<ItemCollection> json

let checkIt x =
    match x with
        | Some item -> (item.JdeNumber, item.Revision, item.Filename)
        | None -> ("","","")

let searchDetails (collectionsPart: ItemCollection) (jdeNum: string) =
    collectionsPart
        |> List.tryFind (fun j -> j.JdeNumber = jdeNum)
        |> checkIt

let item = searchDetails deserialized "200082"

let jdenumber , revision, filename = item // retrun a tuple (a,b,c)
printfn "%s" jdenumber

