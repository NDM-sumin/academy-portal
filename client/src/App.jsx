import { useState } from 'react'
import './App.css'
import useAxios from './apis/app-axios-configuration'
import { BrowserRouter } from 'react-router-dom';
import { App as AntdApp, ConfigProvider } from 'antd';
import { AppContext } from './hooks/context/app-bounding-context';
import AppRoutes from './routes';
function App() {
  const axios = useAxios();
  const [isLoading, setLoading] = useState(false);

  const contextValue = {
    isLoading: isLoading,
    setLoading: setLoading,
    axios: axios,
    user: null,
    setUser: () => { }
  }
  return (
    <ConfigProvider>
      <AppContext.Provider value={contextValue} >

  
          <AppRoutes />
       

      </AppContext.Provider>
    </ConfigProvider>
  )
}

export default App
