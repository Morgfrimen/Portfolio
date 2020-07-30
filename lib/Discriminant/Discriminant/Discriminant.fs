namespace QuadraticEquation

open System.Text.RegularExpressions
open System

type public ResultFullQuadraticEquation =
    | Empty
    | One of double
    | DoobleX of double*double

module internal Extension =
    let internal ReturnDobleArray (str:string) : double[] =
        let rex : Regex = new Regex(@"(\d+\.\d+)|(-\d+\.\d+)")
        let mathCollection : MatchCollection = rex.Matches str
        if mathCollection.Count = 2 then
            let result : double[] = [|double(0) ; double(0)|]
            Array.set result 0 (double(Convert.ToDouble(mathCollection.[0].Value.Replace(".",","))))
            Array.set result 1 (double(Convert.ToDouble(mathCollection.[1].Value.Replace(".",","))))
            result 
        else
            let result : double[] = [|double(0)|]
            Array.set result 0 (double(Convert.ToDouble(mathCollection.[0].Value.Replace(".",","))))
            result

    let internal ReturnResult (res:ResultFullQuadraticEquation) : double[]=
        match res with
        | ResultFullQuadraticEquation.DoobleX -> ReturnDobleArray (res.ToString())
        | ResultFullQuadraticEquation.One -> ReturnDobleArray (res.ToString())
        | ResultFullQuadraticEquation.Empty -> null

//Полные квадратные уравнения
module public FullQuadraticEquation=
    let public FullQuadraticEquationReqcord (a:double, b:double, c:double) :ResultFullQuadraticEquation =
        let D = b**double(2) - double(4) * a * c
        match D with
        | D when D > double(0) -> ResultFullQuadraticEquation.DoobleX (((-b - System.Math.Sqrt(D))/(double(2)*a)),(-b + System.Math.Sqrt(D))/(double(2)*a))
        | D when D = double(0) -> ResultFullQuadraticEquation.One (-b/(double(2)*a))
        | _ -> ResultFullQuadraticEquation.Empty

    let public FullQuadraticEquationDoubleArray (a:double, b:double, c:double) : double[] =
        Extension.ReturnResult (FullQuadraticEquationReqcord (a, b, c))
        

//Не полные квадратные уравнения        
module public IncompleteQuadraticEquation =
    
    //ax^2 + c = 0
    let private B_Zero (a:double,c:double) : ResultFullQuadraticEquation =
        let xSqrt = -c / a
        match xSqrt with
        |xSqrt when xSqrt >= double(0) -> ResultFullQuadraticEquation.DoobleX (System.Math.Sqrt(xSqrt),-System.Math.Sqrt(xSqrt)) 
        |_ -> ResultFullQuadraticEquation.Empty
    
    //ax^2 + bx = 0
    let private C_Zero (a:double,b:double) : ResultFullQuadraticEquation =
        ResultFullQuadraticEquation.DoobleX (double(0),-b/a)

    //ax^2 = 0
    let private BandC_Zero : ResultFullQuadraticEquation =
        ResultFullQuadraticEquation.DoobleX (double(0),double(0))

    let public IncompleteQuadraticEquationReqcord (a:double, b:double, c:double) :ResultFullQuadraticEquation =
        match a,b,c with
        | a,b,c when  a=double(0) && b=double(0) && c = double(0) -> ResultFullQuadraticEquation.DoobleX (double(0),double(0)) 
        | _,b,c when b=double(0) && c = double(0) -> BandC_Zero 
        |_,b,_ when b=double(0) -> B_Zero(a,c)
        |_,_,c when c = double(0) -> C_Zero(a,b)
        |_ -> raise(new Exception("Шаблон оказался с непредсказуемым случаем"))

    let public IncompleteQuadraticEquationDoubleArray (a:double, b:double, c:double) : double[] =
        Extension.ReturnResult (IncompleteQuadraticEquationReqcord (a, b, c))