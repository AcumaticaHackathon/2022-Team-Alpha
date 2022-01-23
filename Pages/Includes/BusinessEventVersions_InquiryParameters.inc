<px:PXTabItem Text="Inquiry Parameters">
<Template>
    <px:PXFormView Width="500" DataMember="BusinessEventInquiryParameters" Caption="Inquiry Parameters" CaptionVisible="False" runat="server" ID="frmBusinessEventInquiryParameters">
        <Template>
            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdBusinessEventInquiryParameters">
                <Levels>
                    <px:PXGridLevel DataMember="BusinessEventInquiryParameters">
                        <Columns>
                            <px:PXGridColumn DataField="Name" Width="220"></px:PXGridColumn>
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                <AutoSize MinHeight="200"></AutoSize>
                <AutoSize MinWidth="200"></AutoSize>
                <ActionBar ActionsVisible="True">
                    <CustomItems>
                        <px:PXToolBarButton Text="Inq Param History"></px:PXToolBarButton>
                    </CustomItems>
                    <Actions>
                        <AddNew Enabled="False"></AddNew>
                        <Delete Enabled="False"></Delete>
                        <EditRecord Enabled="False"></EditRecord>
                        <Save Enabled="False"></Save>
                    </Actions>
                </ActionBar>
            </px:PXGrid>
        </Template>
    </px:PXFormView>
</Template>
</px:PXTabItem>