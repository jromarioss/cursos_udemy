import { useState, useEffect } from "react"

export const useFetch = (url) => {
  const [data, setDate] = useState(null);
  const [config, setConfig] = useState(null);
  const [method, setMethod] = useState(null);
  const [callFetch, setCallFetch] = useState(false);
  const [loading, setLoading] = useState(false);

  const fetchData = async() => {
    try {
      setLoading(true);
      const res = await fetch(url);
      const json = await res.json();
      setDate(json);
    } catch(err) {
      console.log(err.message);
    } finally {
      setLoading(false);
    }
  }

  const httpRequest = async () => {
    setLoading(true);
    if (method === "POST") {
      let fetchOptions = [url, config];

      const res = await fetch(...fetchOptions);
      const json = await res.json();

      setCallFetch(json);
    }
    setLoading(false);
  }

  const httpConfig = (data, method) => {
    setLoading(true);

    if (method === "POST") {
      setConfig({ 
        method,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
      })
    }

    setMethod(method);
    setLoading(false);
  }

  useEffect(() => {
    fetchData();
  }, [url, callFetch]);

  useEffect(() => {
    httpRequest();
  }, [config, method, url]);

  return { data, httpConfig, loading };
}