import axios from "axios"
import {React, useState, useEffect} from "react"
import { Fragment } from "react/cjs/react.production.min";

const JournalistComponent = () => {

    const [journalists, setJournalists] = useState([]);
    
        useEffect(() => {
            axios.get('https://localhost:7208/api/authors').then((response) => {
                setJournalists(response.data)
                console.log(response.data)
            });
        }, []);
    
        return (
            <div class="NågotBraNamnFörJournalistSidan">
            <p>Journalist Lista</p>
            {journalists.map((journalist) => {
                return(
                    <Fragment>
                    <p>{journalist.firstName} {journalist.lastName}</p>
                    </Fragment>
                )
                
            })}
        </div>
        )
}

export default JournalistComponent