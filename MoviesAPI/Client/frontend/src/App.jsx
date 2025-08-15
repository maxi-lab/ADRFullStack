import { useCallback, useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Card from './Components/Card'

import FormMovie from './Components/FormMovie'

function App() {
  const [pelis,setPelis] = useState([])
  useEffect(()=>{fetch("https://localhost:5001/api/Movie")
                .then((r)=>r.json())
                .then(resp=>setPelis((prev)=>[...resp]))
                .catch(e=>console.error(e))},
            [pelis])
  const deleteMovie=(id)=>{
    useCallback(() => {
      setPelis((prev) => prev.filter(peli => peli.id !== id));
    }, [pelis]);
  }
  const addMovie = (newMovie) => {
    setPelis((prev) => [...prev, newMovie]);
  };
  
  return (
    <>
      <h1>Aplicacion de peliculas</h1>
      <FormMovie/>
      {pelis.length === 0 ? <p>Cargando...</p> :pelis.map((peli) => (
      <div>
        <Card key={peli.id} movie={peli} deleteMovie={deleteMovie} />
      </div>
      ))}
      
    </>
  )
}

export default App
