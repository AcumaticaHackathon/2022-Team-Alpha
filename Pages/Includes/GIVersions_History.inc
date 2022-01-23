<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" DataMember="GIVersions" runat="server" ID="frmGIVersions">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGIHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="GIVersions">
                            <Columns>
                                <px:PXGridColumn DataField="Selected" Width="60"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Version" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Name" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="ActionName" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="CreatedDateTime" Width="90"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>