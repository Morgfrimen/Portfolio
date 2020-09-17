//Программа для расчета линейных уравнений по методу Жордана-Гаусса
//На вход приходит матрица коэффициентов и массив значений
//На выходе возвращается сама система и её результат
module Jordan_Gauss

    type public Jordan_Gauss = {Table:System.Double[,] ; ResultTable : System.Double[,] }

    let public StepMethod (data:Jordan_Gauss, indexRow:int, indexColumn:int) : Jordan_Gauss =
        let mutable res = {Table = data.Table;ResultTable = data.ResultTable  }

        if res.ResultTable = null then
            res<-{Table = data.Table;ResultTable = Array2D.create (data.Table.GetLength(0)) (data.Table.GetLength(1)) 0.0}
        
        if res.Table.[indexRow,indexColumn] <> 1.0 then
           let firstElem = res.Table.[indexRow,indexColumn]
           for indexColumn=0 to res.Table.GetLength(1) - 1 do
                if firstElem <> 0.0 
                then  Array2D.set res.ResultTable indexRow indexColumn (res.Table.[indexRow,indexColumn] / firstElem)
                else Array2D.set res.ResultTable indexRow indexColumn 0.0

        for row=0 to res.Table.GetLength(0) - 1 do
            if row <> indexRow then
                let firstElem = res.Table.[row,indexColumn]
                for column=indexColumn to res.Table.GetLength(1) - 1 do
                    Array2D.set res.ResultTable row column (res.Table.[row,column] - (firstElem * res.ResultTable.[indexRow,column]))
        res <- {Table = res.ResultTable;ResultTable = res.ResultTable  }
        
        res
            
            
    let public RunMethod (data:Jordan_Gauss) : Jordan_Gauss =
        let mutable res = {Table = data.Table;ResultTable = Array2D.create (data.Table.GetLength(0)) (data.Table.GetLength(1)) 0.0}
        for row = 0 to data.Table.GetLength(0) - 1 do
            printfn "%i" row
            res <- StepMethod(res,row,row)   
        res


    let public PrintJordan_Gauss (data:Jordan_Gauss) : string =
        data.ToString()
