import Delete from "./Delete";
import EditMovie from "./EditMovie";

export default function Card({ movie, deleteMovie }) {
    return (
        <div className="card">
        <h2>{movie.title}</h2>
        <p>{movie.description}</p>
        <p>{movie.director}</p>
        <Delete id={movie.id} deleteMovie={deleteMovie} />
        <EditMovie movieId={movie.id} />
        </div>
    );
    }