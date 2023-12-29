import { createContext, useContext } from "react";


export const CRUDContext = createContext({
    dataState: [
        {
            totalItems: 0,
            items: []
        },
        () => { }
    ],
    queryState: [
        {
            $filter: null
        },
        () => { }
    ],
    modalState: [
        { open: false },
        () => { }
    ],
    reloadState: [
        false,
        () => {

        }
    ],
    crudApi: {
        create: () => { },
        update: () => { },
        delete: () => { },
        search: () => { },
    },
    columns: [

    ],
    searchBarItems: [

    ],
    form: {
        instance: null,
        items: [

        ]
    }

})
export const useCRUDContext = () => useContext(CRUDContext);