import axios from 'axios'
const urlBase  = 'https://localhost:5000/api/Feriados'

export default{
    get(){
        const promise = axios.get(urlBase)

        const dataPromise = promise.then((response) => response.data)
    
        return dataPromise
    },
    edit(feriado){
        axios.put(urlBase, feriado, {
            headers: {
              'content-Type': 'application/json; charset=UTF-8'
            }
          })
    },
    delete(id){
        var response = false;

        var url = urlBase + '/'+ id
        axios({
            method: 'DELETE',
            url: url,
            headers: { 'Content-Type': 'application/json' }
          })
          .then( response = true)
          .catch(response = false)

          return response
    }
}