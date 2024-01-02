import { createContext, useContext } from "react";

export const CRUDContext = createContext({
	dataState: [
		{
			totalItems: 0,
			items: [],
		},
		() => {},
	],
	queryState: [
		{
			$filter: null,
		},
		() => {},
	],
	modalState: [{ open: false }, () => {}],
	reloadState: [false, () => {}],
	exportState: [false, () => {}],
	importState: [false, () => {}],
	crudApi: {
		create: () => {},
		update: () => {},
		delete: () => {},
		search: () => {},
		exportData: () => {},
		importData: () => {},
	},
	columns: [],
	searchBarItems: [],
	form: {
		instance: null,
		items: [],
	},
});
export const useCRUDContext = () => useContext(CRUDContext);
