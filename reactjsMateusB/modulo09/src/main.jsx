import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import { CounterContextProvider } from './context/CounterContext.jsx'
import { TitleContextProvider } from './context/TitleContext.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <TitleContextProvider>
      <CounterContextProvider>
        <App />
      </CounterContextProvider>
    </TitleContextProvider>
  </React.StrictMode>,
)
