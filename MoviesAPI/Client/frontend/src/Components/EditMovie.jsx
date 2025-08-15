import { useContext } from "react";
import { Context } from "../Context/ContextProvaider.jsx";

export default function EditMovie({movieId}) {
    const {title, setTitle, description, setDescription, director, setDirector} = useContext(Context);
    const handleEdit = () => {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");
        console.log(movieId)
        const raw = JSON.stringify({
            "title": title,
            "id": movieId,
            "description": description,
            "director": director
        });
        console.log(raw);
        const requestOptions = {
            method: "PUT",
            headers: myHeaders,
            body: raw,
            redirect: "follow"
        };

        fetch(`https://localhost:5001/api/Movie/`, requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.error(error))
        .finally(() => {
            setTitle('');
            setDescription('');
            setDirector('');
        });

    }
    return <>
        <button onClick={handleEdit}>Modificar</button>
    </>
}