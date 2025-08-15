import React, {createContext, useState} from "react";
export const Context = createContext();
export default function ContextProvider({children}) {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [director, setDirector] = useState('');

    return (
        <Context.Provider value={{
            title,
            setTitle,
            description,
            setDescription,
            director,
            setDirector
        }}>
            {children}
        </Context.Provider>
    );
}
