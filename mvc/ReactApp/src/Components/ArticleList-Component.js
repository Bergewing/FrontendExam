import axios from "axios"
import {React, useState, useEffect} from "react"




const ArticleListComponent = () =>{

        const [articles, setArticles] = useState([]);
    
        useEffect(() => {
            axios.get('https://localhost:7208/api/articles').then((response) => {
                setArticles(response.data)
            });
        }, []);
    
        return (
        <div class="NågotBraNamnFörArtikelListan">
            {articles.map((article) => {
                return <p>{article.title}</p>
            })}
        </div>
        )
    
}

export default ArticleListComponent