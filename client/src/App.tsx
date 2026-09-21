import { APITester } from "./APITester";
import "./index.css";

import logo from "./logo.svg";
import reactLogo from "./react.svg";
import {Api, type BookDto} from "../Api.ts";
import {use, useEffect, useState} from "react";
import toast from "react-hot-toast";

const MyApi = new Api();

export function App() {

    const [books, setBooks] = useState<BookDto[]>([])
    const [NewBookTitle, setNewBookTitle] = useState("")

    useEffect(() => {
        MyApi.getBooks.libaryGetBooks({page: 1, resultsPerPage: 1}).then(r => {
            const data = r.data;
            setBooks(data);
            
        })
    }, []);

    function CreateBook() {
        MyApi.createBook.libaryCreateBook({
            BookTitle: NewBookTitle,
            AuthorId: "1",
            NumberOfPages: 100
        }).then(r => {
            const duplicate = [...books, r.data];
            setBooks(duplicate);
        }).catch(e => {
            toast(e.error.title)
        })
    }

    return (
    <div className="app">
        {
            books.map(b => {
                return <div key={b.bookId}>{b.bookTitle}</div>
            })
        }
        
        <input value={NewBookTitle} onChange={e => setNewBookTitle(e.target.value)} />
        <button onClick={CreateBook}>Create Book</button>
    </div>
  );
}

export default App;
