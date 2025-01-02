import QtQuick 2.7
import "qrc:/"
IGuiPage
{
	id: q16777222
	objId: 16777222
	x: 0
	y: 0
	width: 480
	height: 272
	IGuiUserView
	{
		id: q536870912
		objId: 536870912
		x: 74
		y: 51
		width: 394
		height: 167
		qm_BorderCornerRadius: 4
		qm_BorderWidth: 1
		qm_RectangleBorder.color:"#ff6b717b"
		qm_FillColor: "#fff7f3f7"
		IGuiListCtrl
		{
			id: qu536870912
			objectName: "qu536870912"
			x: 2
			y: 2
			width: 390
			height: 163
			qm_list.qm_linesPerRow: 1
			qm_list.qm_tableRowHeight: 13
			qm_list.qm_tableMarginLeft: 2
			qm_list.qm_tableMarginRight: 1
			qm_list.qm_tableMarginBottom: 1
			qm_list.qm_tableMarginTop: 1
			qm_list.qm_tableBackColor: "#ffffffff"
			qm_list.qm_tableSelectBackColor: "#ff94b6e7"
			qm_list.qm_tableAlternateBackColor: "#ffe7e7ef"
			qm_list.qm_tableTextColor: "#ff424952"
			qm_list.qm_tableSelectTextColor: "#ffffffff"
			qm_list.qm_tableAlternateTextColor: "#ff424952"
			qm_scrollCtrl: qus536870912

			qm_hasHeader: true
			qm_hasBorder: true
			qm_hasHorizontalScrollBar: true
			qm_hasVerticalScrollBar: true
			qm_list.qm_gridLineStyle: 0
			qm_list.qm_gridLineWidth: 1
			qm_list.qm_gridLineColor: "#ffffffff"
			qm_columnTypeList: [0, 0, 0, 0]
			totalColumnWidth: 365
			qm_headerItem: qh536870912
			IGuiListHeader
			{
				id: qh536870912
				width: 365
				qm_listItem: qu536870912
				qm_columnWidthList: [113, 72, 90, 90]
				color: "#ff84868c"
				qm_tableHeaderTextColor: "#ffffffff"
				qm_tableHeaderValueVarTextAlignmentHorizontal: Text.AlignLeft
				qm_tableHeaderValueVarTextAlignmentVertical: Text.AlignVCenter
				qm_tableHeaderMarginLeft: 3
				qm_tableHeaderMarginRight: 1
				qm_tableHeaderMarginBottom: 1
				qm_tableHeaderMarginTop: 1
				qm_noOfColumns: 4
				qm_tableHeaderHeight: 13
				qm_leftImageID: 36
				qm_leftTileTop: 4
				qm_leftTileBottom: 11
				qm_leftTileRight: 2
				qm_leftTileLeft: 4
				qm_middleImageID: 37
				qm_middleTileTop: 2
				qm_middleTileBottom: 13
				qm_middleTileRight: 2
				qm_middleTileLeft: 2
				qm_rightImageID: 38
				qm_rightTileTop: 4
				qm_rightTileBottom: 11
				qm_rightTileRight: 4
				qm_rightTileLeft: 2
				radius: 2
			}
			IGuiListScrollBarCtrl
			{
				id: qus536870912

			}
		}
	}
}
