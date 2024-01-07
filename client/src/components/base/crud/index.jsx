import { Space, Button } from "antd";
import CRUDSearchBar from "./search-bar";
import CRUDTable from "./table";
import { CRUDContext } from "../../../hooks/context/crud-context";
import CRUDModal from "./modal";
import { useEffect } from "react";

const CRUDPage = ({
	contextValue: {
		columns,
		dataState,
		queryState,
		crudApi,
		searchBarItems,
		modalState,
		reloadState,
		form,
	},
	additionButtons
}) => {
	useEffect(() => {
		reloadState[1](false);
		if (reloadState[0] !== true) {
			return;
		}
		crudApi.search(queryState[0]).then((res) => {
			dataState[1](res);
		});
	}, [reloadState[0]]);

	return (
		<CRUDContext.Provider
			value={{
				columns: columns,
				dataState: dataState,
				queryState: queryState,
				crudApi: crudApi,
				searchBarItems: searchBarItems,
				modalState: modalState,
				reloadState: reloadState,
				form: form,
			}}
		>
			<Space direction="vertical" style={{ width: "100%", height: "100%" }}>
				<CRUDSearchBar additionButton={additionButtons} />
				<CRUDModal />
				<CRUDTable />
			</Space>
		</CRUDContext.Provider>
	);
};
export default CRUDPage;
