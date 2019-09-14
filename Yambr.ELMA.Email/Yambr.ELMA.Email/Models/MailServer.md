<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>8786ded0-8825-482d-9446-e9a6eaf6caa0</Uid>
  <Name>MailServer</Name>
  <DisplayName>MailServer</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>00000000-0000-0000-0000-000000000000</BaseClassUid>
  <Properties>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>757b2769-c9a3-409d-8c82-34048da2027d</Uid>
      <Name>Uid</Name>
      <DisplayName>Уникальный идентификатор</DisplayName>
      <TypeUid>eb6e8ddc-fafe-4e0e-9018-1a7667012579</TypeUid>
      <Settings xsi:type="GuidSettings">
        <FieldName>Uid</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <IsSystem>true</IsSystem>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ReadOnly>true</ReadOnly>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>0</Order>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>799d21e8-dd55-4ca4-a37e-00f21505248b</Uid>
      <Name>Name</Name>
      <DisplayName>Наименование</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>Name</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <Required>true</Required>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>List</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>1</Order>
      <InFastSearch>true</InFastSearch>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>d68fc0d6-18cd-431d-9f80-b862b2e7b972</Uid>
      <Name>CreationDate</Name>
      <DisplayName>Дата создания</DisplayName>
      <TypeUid>dac9211e-e02b-47cd-8868-89a3bfc0f749</TypeUid>
      <Settings xsi:type="DateTimeSettings">
        <FieldName>CreationDate</FieldName>
        <SetCurrentDate>true</SetCurrentDate>
      </Settings>
      <Nullable>false</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>2</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>d0c00d8a-e003-427d-9942-f52cfb77b0f0</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>0ecfadd1-97c0-48a3-a0fa-dfd1ce3167eb</Uid>
      <Name>CreationAuthor</Name>
      <DisplayName>Автор создания</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</SubTypeUid>
      <Settings xsi:type="EntityUserSettings">
        <FieldName>CreationAuthor</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>3</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>b05ac6bd-eb8b-474a-a796-b53831a9967e</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>b7dea550-0cac-4f89-8fc2-1e20f7affab4</Uid>
      <Name>ChangeDate</Name>
      <DisplayName>Дата изменения</DisplayName>
      <TypeUid>dac9211e-e02b-47cd-8868-89a3bfc0f749</TypeUid>
      <Settings xsi:type="DateTimeSettings">
        <FieldName>ChangeDate</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>4</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>12a6c5c4-12f8-4b2e-b7ea-5438974a2d25</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>96cbcbcd-11fd-4982-a29a-419589f12b8c</Uid>
      <Name>ChangeAuthor</Name>
      <DisplayName>Автор изменения</DisplayName>
      <TypeUid>72ed98ca-f260-4671-9bcd-ff1d80235f47</TypeUid>
      <SubTypeUid>cfdeb03c-35e9-45e7-aad8-037d83888f73</SubTypeUid>
      <Settings xsi:type="EntityUserSettings">
        <FieldName>ChangeAuthor</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>5</Order>
      <Handlers>
        <PropertyHandlerInfo>
          <HandlerUid>d152e660-1ee9-4b5f-a614-df280e5b3f98</HandlerUid>
        </PropertyHandlerInfo>
      </Handlers>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>d301f68b-52fb-4203-b4b4-3b137d1f20a3</Uid>
      <Name>ImapHost</Name>
      <DisplayName>Адрес IMAP</DisplayName>
      <TypeUid>9b9aac17-22bb-425c-aa93-9c02c5146965</TypeUid>
      <Settings xsi:type="StringSettings">
        <FieldName>ImapHost</FieldName>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>6</Order>
      <InFastSearch>true</InFastSearch>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>2cbe8b88-74de-4d0f-b975-4958786a69f2</Uid>
      <Name>ImapPort</Name>
      <DisplayName>Порт IMAP</DisplayName>
      <TypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</TypeUid>
      <Settings xsi:type="Int64Settings">
        <FieldName>ImapPort</FieldName>
        <DefaultValue>993</DefaultValue>
      </Settings>
      <Nullable>true</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>7</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
    <PropertyMetadata xsi:type="EntityPropertyMetadata">
      <Uid>66c1b4b5-b162-499b-83db-160af1f686f1</Uid>
      <Name>RequaredSSL</Name>
      <DisplayName>Требуется SSL</DisplayName>
      <TypeUid>9cd56a40-6192-4d8a-840c-c4bd4dfb88eb</TypeUid>
      <Settings xsi:type="BoolSettings">
        <FieldName>RequaredSSL</FieldName>
      </Settings>
      <Nullable>false</Nullable>
      <ViewSettings>
        <Attributes>
          <ViewAttribute>
            <ViewType>Create</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Edit</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ReadOnly>true</ReadOnly>
            <ViewType>Display</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <Visibility>Hidden</Visibility>
            <ViewType>List</ViewType>
          </ViewAttribute>
          <ViewAttribute>
            <ViewType>Filter</ViewType>
          </ViewAttribute>
        </Attributes>
      </ViewSettings>
      <Order>8</Order>
      <Filterable>true</Filterable>
    </PropertyMetadata>
  </Properties>
  <PropertiesDiffContainer />
  <DefaultForms>
    <CreateUid>00000000-0000-0000-0000-000000000000</CreateUid>
    <EditUid>00000000-0000-0000-0000-000000000000</EditUid>
    <DisplayUid>00000000-0000-0000-0000-000000000000</DisplayUid>
    <ActionGuids />
    <FormSettings />
  </DefaultForms>
  <Forms />
  <FormTransformations />
  <FormViews />
  <TableViews>
    <TableView>
      <Uid>c521bb31-e0ff-449f-bb6e-45c5c1c3c132</Uid>
      <ViewType>List</ViewType>
      <SortDescriptors />
      <GroupDescriptors />
    </TableView>
  </TableViews>
  <TitlePropertyUid>799d21e8-dd55-4ca4-a37e-00f21505248b</TitlePropertyUid>
  <Type>Interface</Type>
  <ImplementationUid>27058b45-7262-4578-b0d9-026b2dedd839</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>MailServer</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <ShowInCatalogList>true</ShowInCatalogList>
  <ParentPropertyUid>00000000-0000-0000-0000-000000000000</ParentPropertyUid>
  <IsGroupPropertyUid>00000000-0000-0000-0000-000000000000</IsGroupPropertyUid>
  <Filter>
    <Uid>00000000-0000-0000-0000-000000000000</Uid>
    <BaseClassUid>00000000-0000-0000-0000-000000000000</BaseClassUid>
    <Properties />
    <PropertiesDiffContainer />
    <DefaultForms>
      <CreateUid>00000000-0000-0000-0000-000000000000</CreateUid>
      <EditUid>00000000-0000-0000-0000-000000000000</EditUid>
      <DisplayUid>00000000-0000-0000-0000-000000000000</DisplayUid>
      <ActionGuids />
      <FormSettings />
    </DefaultForms>
    <Forms />
    <FormTransformations />
    <FormViews />
    <TableViews />
    <TitlePropertyUid>00000000-0000-0000-0000-000000000000</TitlePropertyUid>
  </Filter>
  <ImplementedExtensionUids />
  <Actions>
    <Uid>00000000-0000-0000-0000-000000000000</Uid>
    <BaseTypeUid>00000000-0000-0000-0000-000000000000</BaseTypeUid>
    <Values />
  </Actions>
  <TableParts />
</Entity>