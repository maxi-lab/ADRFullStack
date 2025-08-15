export default function Delete({id, deleteMovie}) {
    const handleDelete = () => {
        const requestOptions = {
        method: "DELETE",
        redirect: "follow"
        };

        fetch(`https://localhost:5001/api/Movie/${id}`, requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));
    }
    return (
        <button onClick={() => {
            handleDelete()
            deleteMovie(id) 
        }}>
            Eliminar
        </button>
    );
}