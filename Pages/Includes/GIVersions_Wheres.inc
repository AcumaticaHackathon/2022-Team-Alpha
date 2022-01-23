<px:PXTabItem Text="Wheres">
    <Template>
        <px:PXFormView Width="500" Caption="Wheres" CaptionVisible="False" DataMember="GIWheres" runat="server" ID="frmGIWheres">
            <Template>
                <px:PXGrid NoteIndicator="False" FilesIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGIWheres">
                    <Levels>
                        <px:PXGridLevel DataMember="GIWheres">
                            <Columns>
                                <px:PXGridColumn DataField="DataFieldName" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Condition" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Value1" Width="70"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <EditRecord Enabled="False"></EditRecord>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Where History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>