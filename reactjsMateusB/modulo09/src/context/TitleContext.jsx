import { createContext, useReducer } from 'react'

export const TitleContext = createContext();

const titleColorReducer = (state, action) => {

  switch(action.type) {
    case 'RED':
      return {...state, color: 'red'}
    case 'BLUE':
      return {...state, color: 'blue'}
    default:
      return state
  }
}

export const TitleContextProvider = ({ children }) => {
  const [state, dispach] = useReducer(titleColorReducer, { color: 'red' });

  return (
    <TitleContext.Provider value={{
      ...state,
    }}>
      {children}
    </TitleContext.Provider>
  )
}