import QtQuick 2.7
import "qrc:/"
IGuiPage
{
	id: q16777219
	objId: 16777219
	x: 0
	y: 0
	width: 480
	height: 272
	IGuiAlarmView
	{
		id: q402653185
		objId: 402653185
		x: 79
		y: 48
		width: 382
		height: 168
		qm_BorderCornerRadius: 4
		qm_BorderWidth: 1
		qm_RectangleBorder.color:"#ff6b717b"
		qm_FillColor: "#fff7f3f7"
		IGuiListCtrl
		{
			id: qu402653185
			objectName: "qu402653185"
			x: 2
			y: 2
			width: 378
			height: 162
			qm_list.qm_linesPerRow: 1
			qm_list.qm_tableRowHeight: 13
			qm_list.qm_tableMarginLeft: 2
			qm_list.qm_tableMarginRight: 1
			qm_list.qm_tableMarginBottom: 1
			qm_list.qm_tableMarginTop: 1
			qm_list.qm_tableBackColor: "#ffffffff"
			qm_list.qm_tableSelectBackColor: "#ff94b6e7"
			qm_list.qm_tableAlternateBackColor: "#ffe7e7ef"
			qm_list.qm_tableTextColor: "#ff181c31"
			qm_list.qm_tableSelectTextColor: "#ffffffff"
			qm_list.qm_tableAlternateTextColor: "#ff181c31"
			qm_scrollCtrl: qus402653185

			qm_hasHeader: true
			qm_hasBorder: true
			qm_hasHorizontalScrollBar: true
			qm_hasVerticalScrollBar: true
			qm_list.qm_gridLineStyle: 0
			qm_list.qm_gridLineWidth: 0
			qm_list.qm_gridLineColor: "#ffffffff"
			qm_columnTypeList: [0]
			totalColumnWidth: 353
			qm_headerItem: qh402653185
			IGuiListHeader
			{
				id: qh402653185
				width: 353
				qm_listItem: qu402653185
				qm_columnWidthList: [353]
				color: "#ff000000"
				qm_tableHeaderTextColor: "#ffffffff"
				qm_tableHeaderValueVarTextAlignmentHorizontal: Text.AlignLeft
				qm_tableHeaderValueVarTextAlignmentVertical: Text.AlignVCenter
				qm_tableHeaderMarginLeft: 3
				qm_tableHeaderMarginRight: 1
				qm_tableHeaderMarginBottom: 1
				qm_tableHeaderMarginTop: 1
				qm_noOfColumns: 1
				qm_tableHeaderHeight: 13
				qm_leftImageID: 20
				qm_leftTileTop: 4
				qm_leftTileBottom: 11
				qm_leftTileRight: 2
				qm_leftTileLeft: 4
				qm_middleImageID: 21
				qm_middleTileTop: 2
				qm_middleTileBottom: 13
				qm_middleTileRight: 2
				qm_middleTileLeft: 2
				qm_rightImageID: 22
				qm_rightTileTop: 4
				qm_rightTileBottom: 11
				qm_rightTileRight: 4
				qm_rightTileLeft: 2
				radius: 2
			}
			IGuiListScrollBarCtrl
			{
				id: qus402653185

			}
		}
	}
}
