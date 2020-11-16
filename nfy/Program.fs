open Legivel.Serialization
open System.Collections.Generic

let Inputfilename = @"C:\Users\Slimane\Desktop\dev\json\nfy\fasteners.yaml"
let yaml = System.IO.File.ReadAllText(Inputfilename)


// No commas necessary, it s a cool feature... :)
type FastenerDetails = {
       JdeNumber: string
       Revision: string
       Filename: string
}

// type ListOfFasteners = List of FastenerDetails

let deserialized = Deserialize<FastenerDetails list> yaml
// printfn "%A" deserialized
printfn "%A" deserialized