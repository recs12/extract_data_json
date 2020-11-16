open System

let getUserChoice : string=
    (*Get the user to choice the material for the part replacement.*)
    printfn "Press a number [1,2,3,4,5,6]?"
    let switcher (choice: string) : string=
        match choice with
        | "1" -> "imperial zinc"
        | "2" -> "metric zinc"
        | "3" -> "imperial ss-304"
        | "4" -> "metric ss-304"
        | "5" -> "imperial ss-316"
        | "6" -> "metric ss-316"
        | "?" -> "?"
        | _ -> ""
    let response:string = Console.ReadLine()
    let material =  switcher response
    material

let mat = getUserChoice
printfn "%s" mat |>ignore