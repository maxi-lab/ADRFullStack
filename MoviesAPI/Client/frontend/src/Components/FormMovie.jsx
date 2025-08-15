import { useState,useContext } from "react";
import { Context } from "../Context/ContextProvaider.jsx";

export default function FormMovie({addMovie}) {
    const { title, setTitle, description, setDescription, director, setDirector } = useContext(Context);
    const createMovie = () => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        const raw = JSON.stringify({
        "title": title,
        "description": description,
        "director": director
        });

        const requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow"
        };

        fetch("https://localhost:5001/api/Movie", requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error))
        .finally(()=>{
            setTitle('');
            setDescription('');
            setDirector('');
        });
    }
    return <div>
        <h2>Introducir datos</h2>
        <form>
            <label>Titulo</label>
            <br />
            <input type="text" name="title" value={title} onChange={(e)=>setTitle(e.target.value)} />
            <br/>
            <label>Descripcion</label>
            <br />
            <input type="text" name="description" value={description} onChange={(e)=>setDescription(e.target.value)}/>
            <br/>
            <label>Director</label>
            <br />
            <input type="text" name="director" value={director} onChange={(e)=>setDirector(e.target.value)}/>
            <br/>
            <button onClick={(e)=>{
            e.preventDefault();
            createMovie();
            addMovie({ title, description, director });
            
            }}>Enviar</button>
        </form>
    </div>
}