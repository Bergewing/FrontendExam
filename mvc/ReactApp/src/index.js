import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';
import ArticleListComponent from './Components/ArticleList-Component'; //Kan behöva .js på slutet
import JournalistComponent from './Components/Journalist-Component';
import ImagesComponent from './Components/Images-Component';

const baseUrl = "Admin";
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Routes>
      <Route path='/' element={<App />}>
        <Route path='Articles' element={<ArticleListComponent/>} />
        <Route path='Journalists' element={<JournalistComponent/>} />
        <Route path='Images' element={<ImagesComponent/>} />
      </Route>
    </Routes>
  </BrowserRouter>,
  rootElement);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
