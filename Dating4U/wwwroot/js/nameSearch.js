//SKRIPT FÖR ATT GE ANVÄNDAREN FEEDBACK PÅ INPUT VID SÖK AV NAMN//
//OCH FUNKTION FÖR ATT GENOMFÖRA FILTRERINGEN AV PROFILER
//Knapp-trycket sköts genom onInput-event

//KLICK SEARCH-BUTTON//
var searchKnapp = document.getElementById("searchBtn");
searchKnapp.addEventListener("click", checkInputKorrekt);

function checkInputKorrekt()

{
    //Variabel för att lagra textvärdet från searchInput
    var inputNamnText = document.getElementById('searchInput').value;
    var korrektInput;
    console.log(korrektInput);

        //Namn måste vara längre än 2
        //och endast innehålla bokstäver
        if (/^([a-z]){3,}/i.test(inputNamnText)) {
            korrektInput = true;
            console.log(korrektInput);
        }
        else {
            korrektInput = false;
            console.log(korrektInput);
        }

        //Sökrutan får ej vara tom
         if (inputNamnText == "") {
             korrektInput = false;
             console.log(korrektInput);
         }
        else {
             korrektInput = true;
             console.log(korrektInput);
         }

    if (korrektInput == true) {
        console.log("de gick")
    }
    else {
        console.log("de gick ej")
    }

}