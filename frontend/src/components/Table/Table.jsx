import React, { useEffect } from "react";
import { useTable, useSortBy, usePagination } from "react-table";

import "./Table.scss";

const Table = ({ columns, data, fetchData, pageCount, pageSize }) => {
  const tableOptions = {
    columns,
    data,
    pageCount,
    manualPagination: true,
    autoResetPage: false,
    initalState: {
      pageSize,
      pageIndex: 0,
    },
  };

  const {
    getTableProps,
    getTableBodyProps,
    prepareRow,
    headerGroups,
    canPreviousPage,
    canNextPage,
    pageOptions,
    gotoPage,
    nextPage,
    page,
    previousPage,
    setPageSize,
    state: { pageIndex },
  } = useTable(tableOptions, usePagination);

  useEffect(() => {
    fetchData({ pageIndex, pageSize });
  }, [pageIndex, pageSize, fetchData]);

  return (
    <>
      <table {...getTableProps()}>
        <thead>
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th {...column.getHeaderProps()}>
                  {column.render("Header")}
                  {/* sorting */}
                </th>
              ))}
            </tr>
          ))}
        </thead>
        <tbody {...getTableBodyProps()}>
          {page.map((row) => {
            prepareRow(row);
            return (
              <tr {...row.getRowProps()} className="table__body__tr">
                {row.cells.map((cell, i) => (
                  <td
                    {...cell.getCellProps()}
                    className="table__body__cell"
                    key={i}
                  >
                    {cell.render("Cell")}
                  </td>
                ))}
              </tr>
            );
          })}
        </tbody>
      </table>
      <div className="table__pagination">
        <div className="table__pagination__counter">
          Página <b>{pageIndex + 1}</b> de <b>{pageOptions.length + 1}</b>
        </div>
        <div className="table__pagination__buttons">
          <button
            className="table__pagination__button"
            onClick={() => gotoPage(0)}
            disabled={!canPreviousPage}
          >
            Lefts
            {/* {<FiChevronsLeft />} */}
          </button>
          <button
            className="table__pagination__button"
            onClick={() => previousPage()}
            disabled={!canPreviousPage}
          >
            Left
            {/* {<FiChevronLeft />} */}
          </button>
          <button
            className="table__pagination__button"
            onClick={() => nextPage()}
            disabled={!canNextPage}
          >
            Right
            {/* {<FiChevronRight />} */}
          </button>
          <button
            className="table__pagination__button"
            onClick={() => gotoPage(pageCount - 1)}
            disabled={!canNextPage}
          >
            Rights
            {/* {<FiChevronsRight />} */}
          </button>
        </div>
      </div>
    </>
  );
};

export default Table;
