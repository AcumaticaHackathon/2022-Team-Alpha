<px:PXTabItem Text="Screens">
    <Template>
        <px:PXFormView Width="500" DataMember="ScreenAttributes" runat="server" ID="frmScreenAttributes" Caption="Screen Attributes" CaptionVisible="False">
            <Template>
                <px:PXGrid Height="300" SkinID="Details" runat="server" ID="grdScreenAttributes">
                    <Levels>
                        <px:PXGridLevel DataMember="ScreenAttributes">
                            <Columns>
                                <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Screen History"></px:PXToolBarButton>
                        </CustomItems>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                        </Actions>
                        <Actions>
                            <Delete Enabled="False"></Delete>
                        </Actions>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>