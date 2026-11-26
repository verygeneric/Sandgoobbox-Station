entity-effect-guidebook-modify-disgust =
    { $chance ->
        [1] { $deltasign ->
                [1] Increases
                *[-1] Decreases
            }
        *[other]
            { $deltasign ->
                [1] increase
                *[-1] decrease
            }
    } disgust level by { $amount }

entity-effect-guidebook-unhusk-absorbed =
    { $chance ->
        [1] Restores
        *[other] restore
    } a body hollowed by a changeling, allowing it to be revived
